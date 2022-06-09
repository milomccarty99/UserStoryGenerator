using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserStoryGenerator
{
    class Keyphrases
    {
        //int[] phraseNumbers = new int[3]; // 3 fields so far
        protected Random rand = new Random();
        private string goal;
        private string reason;
        private string situation;
        private string goalsPath = @"..\..\Goals.txt";
        private string reasonsPath = @"..\..\Reasons.txt";
        private string situationsPath = @"..\..\Situations.txt";
        
        public Keyphrases() // only reading 
        {
            //phraseNumbers = new int[] { 0,0,0};

            //read from text files
            //check data
            //testing testing testing
            

            this.goal = GetPhrase(0, goalsPath);
            this.reason = GetPhrase(0, reasonsPath);
            this.situation = GetPhrase(0, situationsPath);
        }
        public Keyphrases(int goalnum, int reasonnum, int situationnum)
        {
            

            this.goal = GetPhrase(goalnum, goalsPath);
            this.reason = GetPhrase(reasonnum, reasonsPath);
            this.situation = GetPhrase(situationnum, situationsPath);
        }
        public string GoalsPhrase()
        {
            return this.goal;
        }
        public string ReasonsPhrase()
        {
            return this.reason;
        }
        public string SituationsPhrase()
        {
            return this.situation;
        }
        public void RandomizePhrases()
        {
            this.goal = GetPhrase(rand.Next(0, GetGoalsLength()), this.goalsPath);
            this.reason = GetPhrase(rand.Next(0, GetReasonsLength()), this.reasonsPath);
            this.situation = GetPhrase(rand.Next(0, GetSituationsLength()), this.situationsPath);
        }
        private string GetPhrase(int lineNumber, string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            int num = int.Parse(lines[0]);
            if(lineNumber>num+1 || lineNumber<0)
            {
                throw new IndexOutOfRangeException("invalid line number given. are you sure you are reading the right file?");
            }

            return lines[lineNumber + 2];// buffer for file data and readability space
        }
        public bool AddPhrase(string phrase, string filePath)
        {
            // read all lines as string[] lines
            string[] lines = new string[] { "0", "" };
            try
            {
                lines = System.IO.File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //find length of file
            int fileLen = int.Parse(lines[0]);
            if (fileLen<=0)
            {
                return false;
            }
            lines[0] = "" + (fileLen + 1); //make iteration and put it in lines
            using (StreamWriter newWriter = new StreamWriter(System.IO.File.OpenWrite(filePath)))
            {
                foreach (string line in lines)
                {
                    newWriter.WriteLine(line);
                }
                newWriter.WriteLine(phrase);
                newWriter.Close();
            }
            
            //appended to the end of the file
            return true;
        } //does not check to see if duplicate exists though a drop down menu will help make this more visible.
        public bool AddGoal(string goal)
        {
            return AddPhrase(goal, this.goalsPath);
        }
        public bool AddReason(string reason)
        {
            return AddPhrase(reason, this.reasonsPath);
        }
        public bool AddSituation(string situation)
        {
            return AddPhrase(situation, this.situationsPath);
        }
        private int GetPhrasesLength(string filePath)
        {
            try
            {
                return int.Parse( System.IO.File.ReadAllLines(filePath)[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //find length of file
            return -1;
        }
        public int GetGoalsLength()
        {
            return GetPhrasesLength(this.goalsPath);
        }
        public int GetReasonsLength()
        {
            return GetPhrasesLength(this.reasonsPath);
        }
        public int GetSituationsLength()
        {
            return GetPhrasesLength(this.situationsPath);
        }
    }
}
