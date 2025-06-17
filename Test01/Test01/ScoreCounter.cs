namespace Test01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);

        }

        //メソッドの概要： 学生のデータを読み込み、Studentオブジェクトのリストを返す
        private static IEnumerable<Student> ReadScore(string filePath) {
            var student = new List<Student>();//リストオブジェクトを生成
            var lines = File.ReadAllLines(filePath); //ファイルを一気に読み込む
            //読み込んだ行数分繰り返し
            foreach (var line in lines) {
                string[] items = line.Split(',');
                //Studentオブジェクトを生成
                var stu = new Student() {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };
                student.Add(stu);
            }
            return student;
        }

        //メソッドの概要： 科目別点数集計を求める
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (Student score in _score) {
                if (dict.ContainsKey(score.Subject))
                    dict[score.Subject] += score.Score;
                else
                    dict[score.Subject] = score.Score;
            }
            return dict;

        }
    }
}
