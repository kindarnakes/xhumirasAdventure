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


        
        //CROSSROAD_START
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira doler cabeza ..."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "No fue buena idea quedarse insconsciente a proposito para entrar en el plano onírico."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira querer dormir."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Me temo que queda algo más por hacer, algo como salvar la puñetera realidad. Tienes ante ti varias opciones."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Puedes usar el portal que nos ha abierto tu última acción y enfrentarnos al devorador."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Puedes ir a hablar con Bennett Reinhardt para que te ayude."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Puedes ir a hablar con Relen Du Raven para que te ayude."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "También te puedes quedar aquí y condenar toda la realidad, y posiblemente todas las conocidas."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira moverse, no dormir..."));
        dialogs.Add("CROSSROAD_START", dialogToAdd);
        dialogToAdd = new List<Dialog>();


        //RELEN_QUEST_START
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "*Xhumira viaja hasta la casa de Relen, el Archimago y golpea la puerta*\nXhumira buscar Maestro Relen"));
        dialogToAdd.Add(new Dialog(Characters.Desconocido.ToString(), "El maestro está ocu..."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira querer ver Maestro Relen.\n*De repente la puerta de la casa comienza a crujir*"));
        dialogToAdd.Add(new Dialog(Characters.Relen.ToString(), "¡PARA! Ya has hecho eso una vez, dejadla entrar."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira venir a ..."));
        dialogToAdd.Add(new Dialog(Characters.Relen.ToString(), "Habla en draconico, pareces estúpida hablando en común."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "*Habla en un idioma distinto*\nQuiero que me ayudes, el gran enemigo de todos acecha, y hay un portal que puede usarse para pelear."));
        dialogToAdd.Add(new Dialog(Characters.Relen.ToString(), "Peticiones, peticiones, he encontrado algo yo también, ayudame a conseguirlo y yo te ayudaré a ti."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Tu pides mucho, hay que darse prisa."));
        dialogToAdd.Add(new Dialog(Characters.Relen.ToString(), "Lo necesito para ayudarte, sabes bien lo que quiero."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Ese libro es peligroso, la coordenada está a punto de volver a darse."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Pero está bien, llevanos al lugar, lo haré."));
        dialogToAdd.Add(new Dialog(Characters.Relen.ToString(), "*El portal se abre y ambos pasan*\nEsta arriba, yo no puedo pasar de aquí. No mueras."));
        dialogs.Add("RELEN_QUEST_START", dialogToAdd);
        dialogToAdd = new List<Dialog>();

        //RELEN_RECRUIT_END
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Lo tengo, tengo tu grimorio pestoso."));
        dialogToAdd.Add(new Dialog(Characters.Desconocido.ToString(), "*Una voz extraña suena en lo profundo*\nNo sabes el mal que has hecho."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira saber. Pero está vez deber ser así."));
        dialogToAdd.Add(new Dialog(Characters.Desconocido.ToString(), "*No hay respuesta*"));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "*Entrega el grimorio y ambos vuelven por el portal*"));
        dialogToAdd.Add(new Dialog(Characters.Relen.ToString(), "Esta bien, hablame de que has preparado para el otro asunto."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "No haber mucho, ser chungo, no saber que esperar."));
        dialogToAdd.Add(new Dialog(Characters.Relen.ToString(), "De nuevo una misión suicida, nada nuevo contigo, mujer."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Es lo que haber."));
        dialogToAdd.Add(new Dialog("", "*¡Relen se ha unido a la batalla final!*"));
        dialogs.Add("RELEN_RECRUIT_END", dialogToAdd);
        dialogToAdd = new List<Dialog>();


        
        //NO_IR
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira ya no tener nada que hacer ahí."));
        dialogs.Add("NO_IR", dialogToAdd);
        dialogToAdd = new List<Dialog>();


        //BENNETT_RECRUIT_START
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "*La mujer llega hasta la mansión del Vizconde Bennett Reinhardt y llama a la puerta.\nRapidamente los criados la dejan pasar.*"));
        dialogToAdd.Add(new Dialog(Characters.Bennett.ToString(), "Es un placer verte de nuevo, Xhumira."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira venir a pedir ayuda."));
        dialogToAdd.Add(new Dialog(Characters.Bennett.ToString(), "Sabes que acudiría a la llamada raudo, mas, no puedo, los libres amenazan la seguridad del reino. Debo ocuparme."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "¿Si Xhumira encargar libres Bennett venir?"));
        dialogToAdd.Add(new Dialog(Characters.Bennett.ToString(), "Si me ayudas a acabar con la amenaza, nada impedira ayudarte."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira matar libres."));
        dialogToAdd.Add(new Dialog(Characters.Bennett.ToString(), "No es necesario matarlos, basta con detenerlos. Deben ser juzgados."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira ya juzgar, ellos molestar.\n*Antes de que Bennett pueda decir nada más, se ha transformado en pájaro y sale volando por la ventana*"));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Sabías desde el principio que tendrías que hacer esto, ¿verdad?"));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Xhumira ya saber donde libres esconderse, si, Xhumira saber todo, Xhumira ser lista."));
        dialogs.Add("BENNETT_RECRUIT_START", dialogToAdd);
        dialogToAdd = new List<Dialog>();


        //BENNETT_RECRUIT_FINAL
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "*Regresa a la casa de Bennett*"));
        dialogToAdd.Add(new Dialog(Characters.Bennett.ToString(), "Se lo que has hecho, no debiste matarlos."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Hecho, hecho está."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "En fin, ya está, te compañaré."));
        dialogs.Add("BENNETT_RECRUIT_FINAL", dialogToAdd);
        dialogToAdd = new List<Dialog>();


        //DARK_SANCTUARY_2
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "Ha llegado la hora."));
        dialogToAdd.Add(new Dialog(Characters.Dragon.ToString(), "Tu lo has dicho, ha llegado la hora de consumirte y acabar con todo."));
        dialogToAdd.Add(new Dialog(Characters.Xhumira.ToString(), "¿QUE?¿QUE?¿QUE?"));
        dialogToAdd.Add(new Dialog(Characters.Cosechador.ToString(), "Yo soy el Gran Cosechador.\nMe has tenido al alcance durante todo este tiempo, pero se acabo, preparate a morir."));
        dialogs.Add("DARK_SANCTUARY_2", dialogToAdd);
        dialogToAdd = new List<Dialog>();

        //DARK_SANCTUARY_2_RELEN
        dialogToAdd.Add(new Dialog(Characters.Relen.ToString(), "Yo me encargo de los hechiceros.\n*Relen esta eliminando a cada hechicero que aparece convocado por el enemigo*"));
        dialogs.Add("DARK_SANCTUARY_2_RELEN", dialogToAdd);
        dialogToAdd = new List<Dialog>();

        
        //DARK_SANCTUARY_2_BENNETT
        dialogToAdd.Add(new Dialog(Characters.Bennett.ToString(), "Sufre el juicio de Pholtus criatura maldita.\n*Bennett lanza una lluvia Axiomatica y el enemigo pierde la mitad de su vida*"));
        dialogs.Add("DARK_SANCTUARY_2_BENNETT", dialogToAdd);
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
