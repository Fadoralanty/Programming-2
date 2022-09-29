using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class GraphTDA 
    {
        private SkillNode origin;
        public void InitializeGraph()
        {
            origin = null;
        }

        public void AddNode(float value, string valueType)
        {
            SkillNode aux = new SkillNode();
            aux.value = value;
            aux.valueType = valueType;
            aux.connection = null;
            aux.nextNode = origin;
            origin = aux;
        }

        public void AddConnection(int id, SkillNode node1, SkillNode node2, float weight)
        {
            SkillConnection aux = new SkillConnection();
            aux.cost = weight;
            aux.destiny = node2;
            aux.nextConnection = node1.connection;
            node1.connection = aux;
        }

        public bool ConnectionExists(SkillNode node1, SkillNode node2)
        {
            throw new NotImplementedException();
        }

        public float ConnectionWeight(SkillNode node1, SkillNode node2)
        {
            throw new NotImplementedException();
        }
        public void RemoveConnection(SkillConnection connection)
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(SkillNode node)
        {
            throw new NotImplementedException();
        }
    }
}
