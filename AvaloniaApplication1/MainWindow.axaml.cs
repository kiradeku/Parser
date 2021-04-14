using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace AvaloniaApplication1
{
    public class MainWindow : Window
    {
        private struct TrueOrFalse
        {
            public string QuestionName;
            public string QuestionText;
            public double MaxPoins;
            public string CorrectAnswer;
            public string WrongAnswer;
        }

        private struct Cloze
        {
            public string QuestionName;
            public string QuestionText;
        }

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public async Task<string> GetPath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter() { Name = "All", Extensions = { "*" } });

            string[] result = await dialog.ShowAsync(this);
            return string.Join(" ", result);
        }
        public async Task<string> GetPathSave()
        {
            SaveFileDialog dialog2 = new SaveFileDialog();
            dialog2.Filters.Add(new FileDialogFilter() { Name = "All", Extensions = { "*" } });
            string result = await dialog2.ShowAsync(this);
            return string.Join(" ", result);
        }
        
        private void WordToXML(string path)
        {
            XDocument xdoc = new XDocument();
            XElement quiz = new XElement("quiz");
            WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(path, true); //Добавить исключение, если файл открыт
            Body body = wordprocessingDocument.MainDocumentPart.Document.Body;
            string EndPath = path.Substring(0, path.Length - 4) + "xml";

            List<string> AllTasks = new List<string>();

            string text = body.InnerText;
            while (text != "")
            {
                string Type = "Тип: ";
                text = text.Substring(Type.Length);
                int IndexOfType = text.IndexOf(Type);
                if (IndexOfType != -1)
                {
                    AllTasks.Add(text.Substring(0, IndexOfType));
                    text = text.Substring(IndexOfType, text.Length - IndexOfType);
                }
                else
                {
                    AllTasks.Add(text);
                    text = "";
                }
            }
            foreach (var Task in AllTasks)
            {
                string Name = "Название: ";
                string QuestionText = "Текст вопроса: ";
                string TaskText = "Текст задания: ";
                string MaxPoins = "Максимум баллов: ";
                string CorrectAnswer = "Правильный ответ: ";
                string WrongAnswer = "Неправильный ответ: ";
                int IndexOfName = Task.IndexOf(Name);
                string Type = Task.Substring(0, IndexOfName);
                Type = Type.Trim();
                int Start = Name.Length + IndexOfName;

                switch (Type)
                {
                    case "Правда или ложь":
                        TrueOrFalse TOF = new TrueOrFalse();
                        TOF.QuestionName = Task.Substring(Start, Task.IndexOf(QuestionText) - Start);
                        Start = Task.IndexOf(QuestionText) + QuestionText.Length;
                        TOF.QuestionText = Task.Substring(Start, Task.IndexOf(MaxPoins) - Start);
                        Start = Task.IndexOf(MaxPoins) + MaxPoins.Length;
                        TOF.MaxPoins = Convert.ToDouble(Task.Substring(Start, Task.IndexOf(CorrectAnswer) - Start));
                        Start = Task.IndexOf(CorrectAnswer) + CorrectAnswer.Length;
                        TOF.CorrectAnswer = Task.Substring(Start, Task.IndexOf(WrongAnswer) - Start);
                        Start = Task.IndexOf(WrongAnswer) + WrongAnswer.Length;
                        TOF.WrongAnswer = Task.Substring(Start, Task.Length - Start);
                        TrueOrFalseAdd(TOF, xdoc, quiz);
                        break;
                    case "cloze":
                        Cloze cloze = new Cloze();
                        cloze.QuestionName = Task.Substring(Start, Task.IndexOf(TaskText) - Start);
                        Start = Task.IndexOf(TaskText) + TaskText.Length;
                        cloze.QuestionText = Task.Substring(Start, Task.Length - Start);
                        ClozeAdd(cloze, xdoc, quiz);
                        break;
                }
            }
            xdoc.Add(quiz);
            xdoc.Save(EndPath);
        }

        private static void TrueOrFalseAdd(TrueOrFalse TOF, XDocument xdoc, XElement quiz)
        {
            XCData xCData = new XCData(TOF.QuestionText);

            //создаем корневой элемент

            XElement question = new XElement("question");
            //создание дочерних элементов
            XElement name = new XElement("name");
            XElement questiontext = new XElement("questiontext");
            XElement generalfeedback = new XElement("generalfeedback");
            XElement defaultgrade = new XElement("defaultgrade", TOF.MaxPoins);
            double penaltyPoint = 1.0 / 3.0;
            XElement penalty = new XElement("penalty", penaltyPoint);
            XElement hidden = new XElement("hidden", 0);
            XElement idnumber = new XElement("idnumber", "");
            XElement answer1 = new XElement("answer");
            XElement answer2 = new XElement("answer");
            XElement feedback = new XElement("feedback");
            XElement TextForName = new XElement("text", TOF.QuestionName);
            XElement TextForQuestiontext = new XElement("text", xCData);
            XElement TextForGuesgeneraleedback = new XElement("text", "");
            XElement TextForGeneralfeedback = new XElement("text", "");
            XElement TextForFeedback = new XElement("text", "");
            XElement TextForFesrtAnswer = new XElement("text", TOF.CorrectAnswer);
            XElement TextForSecondeAnswer = new XElement("text", TOF.WrongAnswer);

            //создаем атрибут
            XAttribute TypeQuestion = new XAttribute("type", "truefalse");
            XAttribute format1 = new XAttribute("format", "html");
            XAttribute format2 = new XAttribute("format", "moodle_auto_format");
            XAttribute fraction100 = new XAttribute("fraction", "100");
            XAttribute fraction0 = new XAttribute("fraction", "0");
            //добавляем элементам элементы и аттребуты
            name.Add(TextForName);
            question.Add(name);
            questiontext.Add(format1);
            questiontext.Add(TextForQuestiontext);
            question.Add(questiontext);
            generalfeedback.Add(TextForGeneralfeedback);
            generalfeedback.Add(format1);
            question.Add(generalfeedback);
            question.Add(defaultgrade);
            question.Add(penalty);
            question.Add(hidden);
            question.Add(idnumber);

            feedback.Add(format1);
            feedback.Add(TextForFeedback);
            answer1.Add(fraction100);
            answer1.Add(format2);
            answer1.Add(TextForFesrtAnswer);
            answer1.Add(feedback);

            question.Add(answer1);

            //feedback.Add(format1);
            //feedback.Add(TextForFeedback);
            answer2.Add(fraction0);
            answer2.Add(format2);
            answer2.Add(TextForSecondeAnswer);
            answer2.Add(feedback);

            question.Add(answer2);
            question.Add(TypeQuestion);
            quiz.Add(question);
        }
        private static void ClozeAdd(Cloze cloze, XDocument xdoc, XElement quiz)
        {
            XCData xCData = new XCData(cloze.QuestionText);
            //создаем документ

            //создаем корневой элемент

            XElement question = new XElement("question");
            //создание дочерних элементов
            XElement name = new XElement("name");
            XElement questiontext = new XElement("questiontext");
            XElement generalfeedback = new XElement("generalfeedback");
            double penaltyPoint = 1.0 / 3.0;
            XElement penalty = new XElement("penalty", penaltyPoint);
            XElement hidden = new XElement("hidden", 0);
            XElement idnumber = new XElement("idnumber", "");
            XElement TextForName = new XElement("text", cloze.QuestionName);
            XElement TextForQuestiontext = new XElement("text", xCData);
            XElement TextForGuesgeneraleedback = new XElement("text", "");
            XElement TextForGeneralfeedback = new XElement("text", "");

            //создаем атрибут
            XAttribute TypeQuestion = new XAttribute("type", "cloze");
            XAttribute format1 = new XAttribute("format", "html");

            //добавляем элементам элементы и аттребуты
            name.Add(TextForName);
            question.Add(name);
            questiontext.Add(format1);
            questiontext.Add(TextForQuestiontext);
            question.Add(questiontext);
            generalfeedback.Add(TextForGeneralfeedback);
            generalfeedback.Add(format1);
            question.Add(generalfeedback);
            question.Add(penalty);
            question.Add(hidden);
            question.Add(idnumber);

            question.Add(TypeQuestion);
            quiz.Add(question);
        }

        public async void OnClickCommand (object sender, RoutedEventArgs args)
        {
            string _path = await GetPath();
            WordToXML(_path);
        }
        public async void OnClickCommand1 (object sender, RoutedEventArgs args)
        {
           string _path = await GetPathSave();
           WordToXML(_path);

        }
    }
}
