namespace HomeWorks
{
    public interface ILinkedList
    {
        int GetCount();
        void AddNode(int value);
        void AddNodeAfter(Node node, int value); 
        void RemoveNode(int index);
        void RemoveNode(Node node);
        Node FindNode(int searchValue);
    }
}
