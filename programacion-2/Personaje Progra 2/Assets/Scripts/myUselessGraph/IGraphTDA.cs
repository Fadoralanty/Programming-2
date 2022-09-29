using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IGraphTDA
    {
        void InitializeGraph();
        void AddNode(int id);
        void RemoveNode(int id);
        void AddConnection(int id, SkillNode node1, SkillNode node2, float weight);
        void RemoveConnection(SkillConnection connection);
        bool ConnectionExists(SkillNode node1, SkillNode node2);
        float ConnectionWeight(SkillNode node1, SkillNode node2);

    }
}
