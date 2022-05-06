using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Notes
{
    class Program
    {
        static void SwitchForChange (string command, List<Note> notes, int index)
        {
            switch (command)
            {
                case "1":
                    {
                        Console.WriteLine("Введите новое название заметки");
                        string title = Console.ReadLine();

                        Console.WriteLine("Введите новую заметку");
                        string text = Console.ReadLine();

                        notes[index - 1].Change(title, text);

                        break;
                    }


                case "2":
                    {
                        Console.WriteLine("Введите новое название заметки");
                        string title = Console.ReadLine();

                        notes[index - 1].ChangeTitle(title);

                        break;
                    }

                case "3":
                    {
                        Console.WriteLine("Введите новую заметку");
                        string text = Console.ReadLine();

                        notes[index - 1].ChangeText(text);

                        break;
                    }

                case "0":
                    {
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Неизвестная команда");
                        break;
                    }
            }
        }

        static void SwitchWorkWithNote (string command, List<Note> notes)
        {

            switch (command)
            {
                case "1":
                    {
                        Console.WriteLine("Введите номер заметки, которую вы хотите посмотреть");
                        string index = Console.ReadLine();

                        try
                        {
                            notes[Int32.Parse(index) - 1].Print();
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Вы ввели неправильный номер");
                            break;
                        }
                    }

                case "2":
                    {
                        Console.WriteLine("Введите номер заметки, которую вы хотите изменить");
                        string index = Console.ReadLine();

                        try
                        {
                            if (notes[Int32.Parse(index) - 1] != null)
                            {
                                Console.WriteLine("Введите команду [1], чтобы поменять заметку полностью, команду [2], чтобы поменять только название, команду [3], чтобы поменять только текст или команду [0] для возврата назад");
                                string commandForChange = Console.ReadLine();

                                SwitchForChange(commandForChange, notes, Int32.Parse(index));
                            }

                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Вы ввели неправильный номер");
                            break;
                        }

                    }

                case "3":
                    {
                        Console.WriteLine("Введите номер заметки, которую вы хотите удалить");
                        string index = Console.ReadLine();

                        try
                        {
                            notes.RemoveAt(Int32.Parse(index) - 1);

                            Console.WriteLine("Заметка была удалена");
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Вы ввели неправильный номер");
                            break;
                        }
                    }

                case "0":
                    {
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Неизвестная команда");
                        break;
                    }
            }
        }

        static void Main(string[] args)
        {
            List<Note> notes;

            try
            {
                string input = "notes.xml";
                XmlSerializer serializer = new XmlSerializer(typeof(List<Note>));
                TextReader FileStream = new StreamReader(input);
                notes =  (List<Note>)serializer.Deserialize(FileStream);
                FileStream.Close();
            }
            catch(Exception)
            {
                notes = new List<Note>();
            }

            bool stop = true;

            while (stop)
            {
                Console.WriteLine("Введите команду [1] для добавления заметки, команду [2] для просмотра всех заметок или команду [0] чтобы сохранить всё и выйти");
                string commandStart = Console.ReadLine();

                switch (commandStart)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите название заметки");
                            string title = Console.ReadLine();

                            Console.WriteLine("Введите заметку");
                            string text = Console.ReadLine();

                            Note note = new Note();
                            note.Add(title, text);
                            notes.Add(note);

                            break;
                        }
                    case "2":
                        {
                            foreach (Note note in notes)
                            {
                                int index = notes.IndexOf(note) + 1;
                                Console.WriteLine(index + ". " + note.GetTitle());
                            }

                            Console.WriteLine("Введите команду [1] для просмотра заметки, команду [2] для её изменения, команду [3] для её удаления или команду [0] для возврата назад");
                            string commandForNote = Console.ReadLine();

                            SwitchWorkWithNote(commandForNote, notes);

                            break;
                        }

                    case "0":
                        {
                            string output = "notes.xml";

                            XmlSerializer serializer = new XmlSerializer(typeof(List<Note>));
                            TextWriter FileStream = new StreamWriter(output);
                            serializer.Serialize(FileStream, notes);
                            FileStream.Close();

                            return;
                        }

                    default:
                        {
                            Console.WriteLine("Неизвестная команда");
                            break;
                        }
                }
            }
        }
    }
}