namespace Graph.Models
{
    public class Network
    {
        private int _totalElements;
        private Dictionary<int, List<int>> adjacencyList = [];

        public Network(int num)
        {
            ValidateNum(num);
            _totalElements = num;
            InitializeList();
        }


        private static void ValidateNum(int n)
        {
            if (n <= 0)
                throw new ArgumentException("O número de elemeentos deve ser maior que zero.");
        }

        private void InitializeList()
        {
            for (int e = 1; e <= _totalElements; e++)
                adjacencyList[e] = [];
        }
    }
}
