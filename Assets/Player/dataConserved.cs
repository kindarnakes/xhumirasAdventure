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
            this.RelenRecruit = data.RelenRecruit;
            this.BennettRecruit = data.BennettRecruit;
        }

        public toXML() { }
        public List<string> conversationPased = new List<string>();

        public float life = 100f;
        public int lvl = 0;
        public float experiencie = 0;
        public float maxLife = 100f;
        public int lifePotions = 0;
        public int RedCauldron = 0;
        public int FireBottle = 0;
        public int Gems = 0;
        public string Scene = "Main_Menu";
        public bool RelenRecruit = false;
        public bool BennettRecruit = false;
    }

    public static dataConserved DATA = new dataConserved();

    public List<string> conversationPased = new List<string>();

    public float life = 10f;
    public int lvl = 1;
    public float experiencie = 0;
    public float maxLife = 10f;
    public bool isFireDamage = false;

    public int lifePotions = 0;
    public int RedCauldron = 0;
    public int FireBottle = 1;
    public int Gems = 0;

    public bool RelenRecruit = false;
    public bool BennettRecruit = false;

    public string Scene = "Main_Menu";
    private dataConserved()
    {

    }

    private void lvlup()
    {
        maxLife = 10f + ((lvl - 1) * 3f);
        lvl += 1;
    }

    public void addExperience(float exp)
    {
        if (lvl < 10)
        {
            var gain = exp - (exp * ((lvl - 1) / 10f));

            experiencie += gain;

            if (experiencie >= 100f)
            {
                experiencie -= 100f;
                lvlup();
            }
        }


    }

    public void startGame()
    {
        conversationPased = new List<string>();
        life = 10f;
        lvl = 1;
        experiencie = 0;
        maxLife = 10f;
        isFireDamage = false;

        lifePotions = 0;
        RedCauldron = 0;
        FireBottle = 1;
        Gems = 0;

        Scene = "Main_Menu";

    }



    public float damageMelee()
    {
        return (5f + (lvl - 1) * 1f);
    }

    public float damageRanged()
    {
        return (4f + (lvl - 1) * 0.8f + (isFireDamage ? 4f : 0f));
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
