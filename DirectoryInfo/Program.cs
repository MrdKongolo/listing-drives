using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DirectoryInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Jouant avec la classe DriveInfo");
            //DirectoryInfo dir = new DirectoryInfo(@"F:\IMG\ESPOIR");
            //RepertoireCourant(dir);
            //AfficherImage();
            //CreationRep();
            //ReadLine();
            //AfficherLecteur();
            DriveInfoClass();
            ReadKey();
        }
        static void RepertoireCourant(DirectoryInfo di)
        {
            //Binding to the current working directory
            //di = new DirectoryInfo(".");
           
            WriteLine($"Nom complet : {di.FullName}");
            WriteLine($"Nom : {di.Name}");
            WriteLine($"Création : {di.CreationTime}");
            WriteLine($"Parent: {di.Parent}");
            WriteLine($"Root : {di.Root}");
            WriteLine($"Attributs : {di.Attributes}");
        }
        static void AfficherImage()
        {
            DirectoryInfo img = new DirectoryInfo(@"F:\IMG\ESPOIR");
            //Obtenir tous les fichiers jpg
            FileInfo[] listeImage = img.GetFiles("*jpg", SearchOption.AllDirectories);
            WriteLine($"Total des images trouvé : {listeImage.Length}"); 
            foreach(FileInfo f in listeImage)
            {
                WriteLine($"Nom du fichier : {f.Name} \tTaille du fichier : {f.Length/1024} KB \tAttributs du fichier : {f.Attributes} \tCréation du fichier : {f.CreationTime} ");               
            }         
        }
        static void CreationRep()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\");
            //Création d'un dossier
            di.CreateSubdirectory("MonDossier");
            //Création d'un dossier dans le dossier précédent
            DirectoryInfo MyDataFolder = di.CreateSubdirectory(@"MonDossier\Données");
            WriteLine($"Le nouveau dossier est : {MyDataFolder}");
        }
        static void AfficherLecteur()
        {
            string[] lecteurs = Directory.GetLogicalDrives();
            WriteLine("Voici la liste de vos lecteurs :");
            foreach (string l in lecteurs)
                WriteLine($"-->{l}");
            WriteLine("Appuyez sur une touche pour supprimer les repertoires crées");
            ReadLine();
            try
            {
                //Directory.Delete(@"C:\MonDossier");
                Directory.Delete(@"C:\MonDossier", true);
                WriteLine("Le dossier a été bien éffacé");
            }
            catch (IOException ex)
            {
                WriteLine(ex.Message);
            }
        }
        static void DriveInfoClass()
        {
            //Obtenir les info de tous les lecteurs
            DriveInfo[] mesLecteurs = DriveInfo.GetDrives();
            foreach(DriveInfo di in mesLecteurs)
            {
                Write($"Nom : {di.Name} \tType : {di.DriveType}");
                if (di.IsReady)
                {
                    Write($"\tFormat : {di.DriveFormat}\tLabel : {di.VolumeLabel}");
                }
                WriteLine();
            }           
        }
    }
}
