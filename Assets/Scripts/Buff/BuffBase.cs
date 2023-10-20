
namespace BuffSystem
{
    public abstract class BuffBase
    {
        private string m_name;
        private string m_description;

        protected BuffBase(string name, string description)
        {
            m_name = name;
            m_description = description;
        }

        abstract public void ApplyBuff();
        abstract public void RemoveBuff();
    }
}
