using Api.Entities.Default;

namespace Api.Entities.QA
{
    public class QAManager : DefaultManager
    {
        private readonly Repository<Question> _qaRes;

        protected QAManager(QAContext qaContext) : base(qaContext)
        {
            _qaRes = new Repository<Question>(qaContext);
        }
    }
}
