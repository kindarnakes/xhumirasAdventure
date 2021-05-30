using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class dataConserved
{
    [XmlRoot("toXML")]
    public class toXML
    {
        public toXML(dataConserved data)
        {
            this.life = data.life;
            this.lvl = data.lvl;
            this.experiencie = data.experiencie;
            this.maxLife = data.maxLife;
            this.lifePotions = data.lifePotions;
            this.RedCauldron = data.RedCauldron;
            this.FireBottle = data.FireBottle;
            this.Gems = data.Gems;
            this.Scene = data.Scene;
            this.conversationPased = data.conversationPased;

        }

        public toXML() { }
        public List<string> conversationPased = new List<string>();

        public float life = 10f;
        public int lvl = 0;
        public int experiencie = 0;
        public float maxLife = 10f;
        public int lifePotions = 0;
        public int RedCauldron = 0;
        public int FireBottle = 0;
        public int Gems = 0;
        public string Scene = "Main_Menu";
    }

    public static dataConserved DATA = new dataConserved();

    public List<string> conversationPased = new List<string>();

    public float life = 5f;
    public int lvl = 0;
    public int experiencie = 0;
    public float maxLife = 10f;
    public bool isFireDamage = false;

    public int lifePotions = 0;
    public int RedCauldron = 0;
    public int FireBottle = 1;
    public int Gems = 0;

    public string Scene = "Main_Menu";
    private dataConserved()
    {

    }

    public void lvlup()
    {
        maxLife = maxLife + (lvl * 1.5f);
        experiencie = 0;
        lvl += 1;
    }

    public float damageMelee(){
        return (5f + lvl*0.5f);
    }

        public float damageRanged(){
        return (4f + lvl*0.4f + (isFireDamage?2f:0f));
    }

    string fileName = Application.persistentDataPath + "/XML/SaveGame.xml";

    public void Save()
    {
        System.IO.FileInfo file = new System.IO.FileInfo(fileName);
        file.Directory.Create();

        XmlSerializer serializer = new XmlSerializer(typeof(toXML));

        using (FileStream stream = new FileStream(fileName, FileMode.Create))
        {
            serializer.Serialize(stream, new toXML(this));
            stream.Close();
        }
    }

    public void Load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(toXML));

        using (FileStream stream = new FileStream(fileName, FileMode.Open))
        {
            var data = serializer.Deserialize(stream) as toXML;
            this.life = data.life;
            this.lvl = data.lvl;
            this.experiencie = data.experiencie;
            this.maxLife = data.maxLife;
            this.lifePotions = data.lifePotions;
            this.RedCauldron = data.RedCauldron;
            this.FireBottle = data.FireBottle;
            this.Gems = data.Gems;
            this.Scene = data.Scene;
            this.conversationPased = data.conversationPased;
            Debug.Log(data);
            stream.Dispose();
            stream.Close();
        }
    }

}
