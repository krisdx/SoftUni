namespace PlayWithTrees
{
    using System.Collections.Generic;
    using System.Linq;

    public class Tree
    {
        private readonly IDictionary<int, Tree> nodesByValue = new Dictionary<int, Tree>();

        public Tree(int value, params Tree[] children)
        {
            this.Value = value;
            this.nodesByValue.Add(this.Value, this);

            this.Children = new List<Tree>();
            foreach (var child in children)
            {
                child.Parent = this;
                this.Children.Add(child);
            }
        }

        public Tree()
            : this(default(int))
        {
        }

        public int Value { get; set; }

        public Tree Parent { get; set; }

        public IList<Tree> Children { get; private set; }

        public void AddChild(Tree child, Tree parent)
        {
            child.Parent = parent;
            parent.Children.Add(child);
        }

        public Tree GetTreeNodeByValue(int value)
        {
            if (!this.nodesByValue.ContainsKey(value))
            {
                this.nodesByValue[value] = new Tree(value);
            }

            return this.nodesByValue[value];
        }

        public Tree RootNode()
        {
            var parentNode = this.nodesByValue.Values.FirstOrDefault(node => node.Parent == null);
            return parentNode;
        }

        public IEnumerable<Tree> GetLeafNodes()
        {
            var leafNodes = this.nodesByValue.Values
                .Where(node => node.Children.Count == 0)
                .OrderBy(node => node.Value);

            return leafNodes;
        }

        public IEnumerable<Tree> GetMiddleNodes()
        {
            var leadNodes = this.nodesByValue.Values
                .Where(node => node.Parent != null && node.Children.Count > 0)
                .OrderBy(node => node.Value);

            return leadNodes;
        }

        public IList<Tree> FindLongestPath()
        {
            var longestPathNodes = this.GetLongestPath();
            longestPathNodes.Reverse();

            return longestPathNodes;
        }
        
        public override string ToString()
        {
            return this.Value.ToString();
        }

        private List<Tree> GetLongestPath()
        {
            var longestPathNodes = new List<Tree>();

            foreach (var child in this.Children)
            {
                var currentPathNodes = child.GetLongestPath();
                if (currentPathNodes.Count > longestPathNodes.Count)
                {
                    longestPathNodes = currentPathNodes;
                }
            }

            longestPathNodes.Add(this);

            return longestPathNodes;
        }
    }
}