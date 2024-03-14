using System;
using System.Collections.Generic;
[Serializable]
public class PlayerDatum
{
    public string _id;
    public string username;
    public string firstname;
    public string lastname;
    public int score;
    public int wins;
    public int __v;
}
[Serializable]
public class Root
{
    public PlayerDatum[] playerdata;
}