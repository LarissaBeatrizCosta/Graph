namespace Graph.Models
{
    /// Classe responsável por representar uma rede de elementos conectados.
    /// Permite a criação de conexões entre os elementos e valida os dados
    public class Network
    {
        /// Número total de elementos na rede.
        private readonly int _totalElements;

        /// Lista de adjacência que representa as conexões entre os elementos.
        /// Exemplo: {1: [2, 3], 2: [1], 3: [1]}
        private readonly Dictionary<int, List<int>> adjacencyList = [];

        /// Inicializa uma nova instância da classe Network com um número especificado de elementos.
        /// Valida o número de elementos, atribui o total de elementos e inicializa a lista de adjacência.
        public Network(int num)
        {
            ValidateNum(num);
            _totalElements = num;
            InitializeList();
        }

        /// Conecta um nó a outro na rede.
        /// Valida os números dos nós, verifica se são diferentes e dentro do intervalo permitido.
        /// Adiciona a conexão na lista de adjacência.
        public void Connect(int num1, int num2)
        {
            ValidateElement(num1);
            ValidateElement(num2);

            if (num1 == num2)
                throw new ArgumentException("Números inválidos.");

            /// Adiciona a conexão na lista de adjacência.
            /// ex: num1 = 1, num2 = 2 => {1: [2], 2: [1]}
            adjacencyList[num1].Add(num2);
            adjacencyList[num2].Add(num1);

        }

        /// Valida se o número de elementos é maior que zero.
        private static void ValidateNum(int n)
        {
            if (n <= 0)
                throw new ArgumentException("O número de elemeentos deve ser maior que zero.");
        }

        /// Valida se o número do elemento é maior que zero e menor ou igual ao número total de elementos.
        private void ValidateElement(int e)
        {
            if (e <= 0 || e > _totalElements)
                throw new ArgumentException("O número do elemento deve ser maior que zero e menor ou igual ao número total de elementos.");
        }

        /// Inicializa a lista de adjacência para todos os elementos na rede.
        private void InitializeList()
        {
            for (int e = 1; e <= _totalElements; e++)
                adjacencyList[e] = [];
        }
    }
}
