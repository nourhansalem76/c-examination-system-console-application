using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public abstract class QuestionBase
    {
        protected string body;
        protected double marks;
        Answers[] answerList;
        private Answers rightAnswer;
        public abstract string Header { get; }

        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public double Marks
        {
            get { return marks; }
            set { marks = value; }
        }
        public Answers RightAnswer
        {
            get { return rightAnswer; }
            set { rightAnswer = value; }
        }
        public Answers[] AnswerList
        {
            get { return answerList; }
            set
            {
                answerList = value;
            }
        }

        public Answers this[int id] {
            get
            {
                for(int i = 0; i< answerList?.Length; i++) {
                    if (answerList[i].AnswerId == id) return answerList[i];
                }
                return new Answers();
            }
        }
        public Answers this[string text]
        {
            get
            {
                for(int i=0;i < answerList?.Length;i++)
                {
                    if (answerList[i].AnswerText ==text) return answerList[i];
                }
                return new Answers();
            }
        }

        public QuestionBase(string _body, double _marks )
        {
            body = _body;
            marks = _marks;
        }

        public static QuestionBase[] CreateBaseQuestions(int size)
        {
            QuestionBase[] questions = new QuestionBase[size]; 
             for(int i=0; i <questions?.Length;i++)
            {
                int questionType;
                do
                {
                    Console.WriteLine($"Please Choose The Type of the Question Number {i + 1} [1 for T/F Question, 2 for Choose one Quesion, 3 for MCQ ] ");

                } while (!int.TryParse(Console.ReadLine(),out questionType)|| questionType < 1 || questionType >3);
                
                if(questionType == 1 )
                {
                    Console.WriteLine($"The Data OF True or False Question Number {i+1}");
                    questions[i] = TFQuestions.AddTFQuestion();
                }
                else if(questionType == 2 )
                {
                    Console.WriteLine($"The Data of Choose One Question Number {i + 1}");
                    questions[i]= ChooseOneQuestions.AddChooseOneQuestion();
                     
                }
                else if(questionType == 3)
                {
                    Console.WriteLine($"The Data of MCQ Question Number {i + 1}");
                    questions[i] =MCQQuestions.AddMCQQuestion();

                }
            }
            return questions;
        }
    }
}
