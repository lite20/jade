using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Net : MonoBehaviour
{
    public bool running = false;

    public GameObject netInstancePrefab;

    private Byte[] mStreamBuffer;

    private NetworkStream stream;

    IEnumerator NetHandle(String ip, int port)
    {
        running = true;

        TcpClient client = new TcpClient(ip, port);
        stream = client.GetStream();
        StreamReader input = new StreamReader(stream);

        while (running)
        {
            if (!stream.DataAvailable)
            {
                yield return new WaitForSeconds(0.1f);
                continue;
            }

            String[] cmd = input.ReadLine().Split('+');
            if (cmd[0] == "CREATE")
            {
                // deserialize command
                NetCmd.Create createCmd =
                    JsonConvert.DeserializeObject<NetCmd.Create>(cmd[1]);

                // create game object
                GameObject go = Instantiate(
                    netInstancePrefab,
                    new Vector3(createCmd.x, createCmd.y, createCmd.z),
                    Quaternion.identity
                );

                // add identity
                NetStat.Identity i = go.AddComponent<NetStat.Identity>();
                i.id = createCmd.id;
                i.iname = createCmd.name;
                
                // set game object name
                go.name = createCmd.id;
            }
            else
            {
                // get net operator for the object
                GameObject go = GameObject.Find(cmd[1]);
                NetOperator no = go.GetComponent<NetOperator>();

                // hand off command to object's net operator
                if (cmd.Length > 1) no.Handle(cmd[0], cmd[2]);
                else no.Handle(cmd[0], null);
            }
        }

        // clean up
        input.Close();
        stream.Close();
        client.Close();
    }

    private void StreamWrite(String msg)
    {
        byte[] data = Encoding.ASCII.GetBytes(msg);
        stream.Write(data, 0, data.Length);
    }

    void Start()
    {
        mStreamBuffer = new Byte[256];

        StartCoroutine(NetHandle("127.0.0.1", 1232));
    }
}
