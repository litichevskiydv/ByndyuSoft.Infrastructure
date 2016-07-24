namespace ByndyuSoft.Infrastructure.Tests.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Moq;

    public static class MockQueryBuilderExtensions
    {
        public static Mock<IQueryBuilder> ReturnObjectForCriterion<TCriterion, TResult>(
            this Mock<IQueryBuilder> mockQueryBuilder, TResult result) where TCriterion : ICriterion
        {
            var mockQueryFor = new Mock<IQueryFor<TResult>>();
            mockQueryFor.Setup(x => x.With(It.IsAny<TCriterion>()))
                .Returns(result);
            mockQueryBuilder.Setup(x => x.For<TResult>()).Returns(mockQueryFor.Object);
            return mockQueryBuilder;
        }

        public static Mock<IQueryBuilder> ReturnEmptyCollectionForCriterion<TCriterion, TEntity>(
            this Mock<IQueryBuilder> mockQueryBuilder) where TCriterion : ICriterion
        {
            return ReturnObjectForCriterion<TCriterion, IEnumerable<TEntity>>(mockQueryBuilder,
                Enumerable.Empty<TEntity>());
        }

        public static Mock<IQueryBuilder> ReturnCollectionForCriterion<TCriterion, TEntity>(
            this Mock<IQueryBuilder> mockQueryBuilder, IEnumerable<TEntity> result) where TCriterion : ICriterion
        {
            return ReturnObjectForCriterion<TCriterion, IEnumerable<TEntity>>(mockQueryBuilder, result);
        }
    }
}