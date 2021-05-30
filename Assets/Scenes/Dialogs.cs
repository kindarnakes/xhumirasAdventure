using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Dialogs
{
    public enum Characters
    {
        Dragon,
        Xhumira,
        Bennett,
        Relen,
        Desconocido,
        Cosechador

    }
    public class Dialog
    {

        public string name { get; set; }
        public string dialog { get; set; }

        public Dialog(string newname, string newdialog)
        {
            name = newname;
            dialog = newdialog;
        }

    }
    public Dictionary<string, List<Dialog>> dialogs = new Dictionary<string, List<Dialog>>();
    private readonly static Dialogs _instance = new Dialogs();

    private Dialogs()
    {
        List<Dialog> dialogToAdd = new List<Dialog>();
        //dialogToAdd.Add(new Dialog("nameCharacter", "dialog")); Add Dialog
        //dialogs.Add("DIALOG_NAME", dialogToAdd); Add Dialog

        //START_GAME
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Despierta, no es momento para dormirse."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira no dormir."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "¿Recuerdas porque estás aquí?"));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira buscar algo, dragón saber que."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Por ahora, busca la entrada a la cueva, debes darte prisa."));
        dialogs.Add("START_GAME", dialogToAdd);
        dialogToAdd = new List<Dialog>();

        //OPEN_CAVE
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Puerta abrirse, ¿porque sonar música?"));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Recuerda donde estamos."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira no saber."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Cuando llegues a lo que buscamos lo recordarás."));
        dialogs.Add("OPEN_CAVE", dialogToAdd);
        dialogToAdd = new List<Dialog>();

        //DARK_CAVE
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Lugar oler a azufre."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Hay más hechiceros aquí, pero eso no será\nun problema para ti ¿verdad?"));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira comer tripas de magos pestosos."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Debes continuar e interrumpir el ritual\nno tienes tiempo para eso."));
        dialogs.Add("DARK_CAVE", dialogToAdd);
        dialogToAdd = new List<Dialog>();

        //DARK_CAVE_END
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira oir cantos."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Ese es nuestro objetivo, debes pararlos"));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "¿Parar que?"));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Estan invocando un avatar de No-Nacido, debes evitar que lo hagan."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira saber que parar un ritual ser peligroso."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Más peligroso es que lo acaben, o los detienes o abrirán la puerta\nal final de todo."));
        dialogs.Add("DARK_CAVE_END", dialogToAdd);
        dialogToAdd = new List<Dialog>();

        //DARK_SANCTUARY_START
        dialogToAdd.Add(new Dialog(Characters.Desconocido.ToString(), "Has tardado mucho, se acabo."));
        dialogToAdd.Add(new Dialog(Characters.Desconocido.ToString(), "La profecía se ha cumplido.\n*Risa Maligna*"));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira parar engendro come mundos."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "¡¡NO NO NO!!\nQue esa cosa no te consuma o todas las realidades se destruirán.\n¡Huye insensata!"));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira decir que parar engendro come mundos y Xhumira hacer."));
        dialogs.Add("DARK_SANCTUARY_START", dialogToAdd);
        dialogToAdd = new List<Dialog>();

        //DARK_SANCTUARY_END
        dialogToAdd.Add(new Dialog(Characters.Desconocido.ToString(), "¡NOOOOOOOOO!\nEstupida"));
        dialogToAdd.Add(new Dialog(Characters.Desconocido.ToString(), "Todos estáis condenados.\n*La figura oscura se marcha*"));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira decir y hacer."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Lo has ... lo has conseguido\n*El remolino de oscuridad en el que se deshace el ser toca a Xhumira*"));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira ser chula, ahora dragón contar que pasar."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Estamos en el plano onírico de una secta de magos.\nTú los forzaste a venir aquí."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "¿Xhumira matar magos en plano material?"));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "No, no podías matarlos, cambiaron a este plano y tuviste que dormir para seguirlos."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Ahora es momento de despertar, la grieta esta cerrada, pero no será la última ..."));
        dialogs.Add("DARK_SANCTUARY_END", dialogToAdd);
        dialogToAdd = new List<Dialog>();


    }

    public static Dialogs Instance
    {
        get
        {
            return _instance;
        }
    }
}
