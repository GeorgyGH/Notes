using System;

namespace Notes
{
    [Serializable]
    public class Note : IDisposable
    {

        public string title;

        public string text;

        public void Add (string _title, string _text)
        {
            title = _title;
            text = _text;

            Console.WriteLine("Заметка была успешно добавленна");
        }

        public void Change (string _title, string _text)
        {
            title = _title;
            text = _text;

            Console.WriteLine("Заметка была успешно обновлена");
        }

        public void ChangeTitle(string _title)
        {
            title = _title;

            Console.WriteLine("Название заметки было успешно обновлено");
        }

        public void ChangeText(string _text)
        {
            text = _text;

            Console.WriteLine("Текст заметки был успешно обновлен");
        }

        public void Print()
        {
            Console.WriteLine("Название:" + title);
            Console.WriteLine("Текст заметки:" + text);
        }

        public void Dispose()
        {
            Console.WriteLine("Заметка была удалена");
        }

        public string GetTitle()
        {
            return title;
        }
    }
}
