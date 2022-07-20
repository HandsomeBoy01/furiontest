using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;

namespace Test
{
    public class TestService : IDynamicApiController
    {
        private IBusinessService _businessService;

        public TestService(INamedServiceProvider<IBusinessService> provider, Func<string, IScoped, object> resolveNamed)
        {
            //这种不行 获取为null
            _businessService = provider.GetService<IBusinessService>(nameof(OtherBusinessService));
            //这种可以
            // _businessService = provider.GetService(nameof(OtherBusinessService));
            //这种也可以
            //_businessService = resolveNamed(nameof(OtherBusinessService), default) as IBusinessService;
        }

        [HttpGet]
        public string TestAsync()
        {
            return _businessService.GetName();
        }
    }

    public interface IBusinessService : IScoped
    {
        string GetName();
    }

    public class BusinessService : IBusinessService
    {
        public string GetName()
        {
            return "我是：" + nameof(BusinessService);
        }
    }

    public class OtherBusinessService : IBusinessService
    {
        public string GetName()
        {
            return "我是：" + nameof(OtherBusinessService);
        }
    }
}
