namespace Graph.Models
{
    /// Classe responsável por representar uma rede de elementos conectados.
    /// Permite a criação de conexões, desconexões e consulta de conexões entre os elementos e valida os dados
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
            ValidateElementsAreDifferent(num1, num2);
            ValidateConnectionNotExist(num1, num2);

            /// Adiciona a conexão na lista de adjacência.
            /// ex: num1 = 1, num2 = 2 => {1: [2], 2: [1]}
            adjacencyList[num1].Add(num2);
            adjacencyList[num2].Add(num1);

        }

        /// Desconecta um nó a outro na rede.
        /// Valida os números dos nós, verifica se são diferentes e dentro do intervalo permitido.
        /// Remove a conexão na lista de adjacência.
        public void Disconnect(int num1, int num2)
        {
            ValidateElement(num1);
            ValidateElement(num2);
            ValidateElementsAreDifferent(num1, num2);
            ValidateConnectionExists(num1, num2);

            adjacencyList[num1].Remove(num2);
            adjacencyList[num2].Remove(num1);

        }

        /// Retorna o nível de conexão entre dois elementos na rede.
        public int LevelConnetion(int num1, int num2)
        {
            ValidateElement(num1);
            ValidateElement(num2);
            ValidateElementsAreDifferent(num1, num2);

            /// Usa busca em largura (BFS) para encontrar o nível de conexão entre os dois elementos.
            var visited = new HashSet<int>();
            /// Cria uma fila para armazenar os nós e o nível de conexão visitados.
            /// ex: (1, 0) => nó 1, nível de conexão 0
            var queue = new Queue<(int node, int connectionLevel)>();

            /// Adiciona o nó inicial à fila com nível de conexão 0.
            queue.Enqueue((num1, 0));

            /// Enquanto a fila não estiver vazia, continua a busca.
            while (queue.Count > 0)
            {
                /// Remove o primeiro nó da fila.
                var (currentNode, connectionLevel) = queue.Dequeue();

                /// Se o nó ainda não foi visitado, marca como visitado.
                if (visited.Add(currentNode))
                {
                    /// Se o nó atual for o nó de destino, retorna o nível de conexão.
                    if (currentNode == num2)
                        return connectionLevel;

                    /// Adiciona os vizinhos do nó atual à fila com nível de conexão incrementado.
                    foreach (var neighbor in adjacencyList[currentNode])
                    {
                        queue.Enqueue((neighbor, connectionLevel + 1));
                    }

                }
            }
            /// Se não houver caminho entre os dois elementos, retorna 0.
            return 0;
        }

        public bool Query(int num1, int num2)
        {
            ValidateElement(num1);
            ValidateElement(num2);

            /// Se o nível de conexão for diferente de 0, significa que existe caminho entre eles
            return LevelConnetion(num1, num2) != 0;
        }

        /// Valida se o número de elementos é maior que zero.
        private static void ValidateNum(int n)
        {
            if (n <= 0)
                throw new ArgumentException("O número de elementos deve ser maior que zero.");
        }

        /// Valida se o número do elemento é maior que zero e menor ou igual ao número total de elementos.
        private void ValidateElement(int e)
        {
            if (e <= 0 || e > _totalElements)
                throw new ArgumentException("O número do elemento deve ser maior que zero e menor ou igual ao número total de elementos.");
        }

        /// Valida se a conexão já existe 
        private void ValidateConnectionNotExist(int num1, int num2)
        {
            if (adjacencyList[num1].Contains(num2))
                throw new ArgumentException("A conexão entre os elementos já existe.");
        }

        /// Valida se a conexão realmente existe 
        private void ValidateConnectionExists(int num1, int num2)
        {
            if (!adjacencyList[num1].Contains(num2))
                throw new ArgumentException("A conexão entre os elementos não existe.");
        }


        /// Valida se os dois elementos são diferentes.
        private static void ValidateElementsAreDifferent(int num1, int num2)
        {
            if (num1 == num2)
                throw new ArgumentException("Os elementos devem ser diferentes.");
        }

        /// Inicializa a lista de adjacência para todos os elementos na rede.
        private void InitializeList()
        {
            for (int e = 1; e <= _totalElements; e++)
                adjacencyList[e] = [];
        }
    }
}
