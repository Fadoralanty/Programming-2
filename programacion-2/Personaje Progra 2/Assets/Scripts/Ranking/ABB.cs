public class ABB : ABBTDA
{
    NodeABB root;

    public PlayerInfo Root() => root.info;

    public bool TreeEmpty() => (root == null);

    public ABBTDA RightSon() => root.RightSon;

    public ABBTDA LeftSon() => root.LeftSon;

    public void InitiateTree() => root = null;

    public void AddElement(PlayerInfo player)
    {
        if (root == null) 
        {
            root = new NodeABB();
            root.info = player;
            root.LeftSon = new ABB();
            root.LeftSon.InitiateTree();
            root.RightSon = new ABB();
            root.RightSon.InitiateTree();
        }
        else if (root.info.Score > player.Score)
        {
            root.LeftSon.AddElement(player);
        }
        else if (root.info.Score < player.Score)
        {
            root.RightSon.AddElement(player);
        }
    }

    public void RemoveElement(PlayerInfo player)
    {
        if (root != null)
        {
            if (root.info.Score == player.Score && root.LeftSon.TreeEmpty() && root.RightSon.TreeEmpty())
            {
                root = null;
            }
            else if (root.info.Score == player.Score && !root.LeftSon.TreeEmpty())
            {
                root.info = this.Higher(root.LeftSon);
                root.LeftSon.RemoveElement(root.info);
            }
            else if (root.info == player && root.LeftSon.TreeEmpty())
            {
                root.info = this.Lower(root.RightSon);
                root.RightSon.RemoveElement(root.info);
            }
            else if (root.info.Score < player.Score)
            {
                root.RightSon.RemoveElement(player);
            }
            else
            {
                root.LeftSon.RemoveElement(player);
            }
        }
    }

    public PlayerInfo Higher(ABBTDA a)
    {
        if (a.RightSon().TreeEmpty())
        {
            return a.Root();
        }
        else
        {
            return Higher(a.RightSon());
        }
    }

    public PlayerInfo Lower(ABBTDA a)
    {
        if (a.LeftSon().TreeEmpty())
        {
            return a.Root();
        }
        else
        {
            return Lower(a.LeftSon());
        }
    }

}