﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<SubCategoryManager>().As<ISubCategoryService>();
            builder.RegisterType<EFSubCategoryDal>().As<ISubCategoryDal>();

            builder.RegisterType<TeacherManager>().As<ITeacherService>();
            builder.RegisterType<EfTeacherDal>().As<ITeacherDal>();

            builder.RegisterType<FaqManager>().As<IFaqService>();
            builder.RegisterType<EfFaqDal>().As<IFaqDal>();

            builder.RegisterType<FaqAnswerManager>().As<IFaqAnswerService>();
            builder.RegisterType<EFaqAnswerDal>().As<IFaqAnswerDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<CourseManager>().As<ICourseService>();
            builder.RegisterType<EfCourseDal>().As<ICourseDal>();


            builder.RegisterType<SupportQuestionManager>().As<ISupportQuestionService>();
            builder.RegisterType<EfSupportQuestionDal>().As<ISupportQuestionDal>();

            builder.RegisterType<SupportAnswerManager>().As<ISupportAnswerService>();
            builder.RegisterType<EfSupportAnswerDal>().As<ISupportAnswerDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
