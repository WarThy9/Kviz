using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Kviz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Question> questions;
        private int currentIndex;
        private int score;

        public MainWindow()
        {
            InitializeComponent();
            questions = new List<Question>();
            LoadQuestions();
            DisplayQuestion();
        }

        private void LoadQuestions()
        {
            questions.Add(new Question
            {
                Text = "Jaký je hlavní město Francie?",
                Answers = new[] { "Paříž", "Londýn", "Washington D.C.", "Tokyo" },
                CorrectAnswer = 0
            });
            questions.Add(new Question
            {
                Text = "Jaký je hlavní město Japonska?",
                Answers = new[] { "Paříž", "Londýn", "Washington D.C.", "Tokyo" },
                CorrectAnswer = 3
            });
            questions.Add(new Question
            {
                Text = "Jaký je hlavní město Anglie?",
                Answers = new[] { "Paříž", "Londýn", "Washington D.C.", "Tokyo" },
                CorrectAnswer = 1
            });
            questions.Add(new Question
            {
                Text = "Jaký je hlavní město USA?",
                Answers = new[] { "Paříž", "Londýn", "Washington D.C.", "Tokyo" },
                CorrectAnswer = 2
            });
            questions.Add(new Question
            {
                Text = "Smrdí ptákovi péro?",
                Answers = new[] { "ANO", "JO", "SOUHLASÍM", "URČITĚ" },
                CorrectAnswer = 3
            });
        }
        private void DisplayQuestion()
        {
            var question = questions[currentIndex];
            lblQuestion.Content = question.Text;
            stackAnswers.Children.Clear();
            for (int i = 0; i < question.Answers.Length; i++)
            {
                var radioButton = new RadioButton
                {
                    Content = question.Answers[i],
                    Tag = i,
                    FontSize = 20,
                    Foreground = Brushes.White,
                    FontFamily = new FontFamily("Arial"),
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 45, 0, 0)
                };
                radioButton.Checked += RadioButton_Checked;
                stackAnswers.Children.Add(radioButton);
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex < questions.Count)
            {
                DisplayQuestion();
            }
            else
            {
                MessageBox.Show($"Tvoje skore je {score} ze {questions.Count}");
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            var answer = (int)radioButton.Tag;
            var question = questions[currentIndex];
            if (answer == question.CorrectAnswer)
            {
                score++;
            }
            foreach (RadioButton rb in stackAnswers.Children)
            {
                rb.IsEnabled = false;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            currentIndex = 0;
            score = 0;
            DisplayQuestion();
        }
    }
}
