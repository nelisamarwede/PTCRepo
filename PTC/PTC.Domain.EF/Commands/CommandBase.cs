

using PTC.Domain.EF.Context;

namespace PTC.Domain.EF.Commands
{
    public abstract class CommandBase
    {
        #region Locals

        protected readonly ApplicationContext _context;

        #endregion


        public CommandBase(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

    }
}
