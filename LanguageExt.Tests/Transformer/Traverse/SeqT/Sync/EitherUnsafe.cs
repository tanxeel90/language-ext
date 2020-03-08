using LanguageExt.Common;
using Xunit;
using static LanguageExt.Prelude;

namespace LanguageExt.Tests.Transformer.Traverse.SeqT.Sync
{
    public class EitherUnsafeSeq
    {
        [Fact]
        public void LeftIsEmpty()
        {
            var ma = LeftUnsafe<Error, Seq<int>>(Error.New("alt"));

            var mb = ma.Sequence();

            Assert.True(mb == Empty);
        }

        [Fact]
        public void RightUnsafeEmptyIsEmpty()
        {
            var ma = RightUnsafe<Error, Seq<int>>(Empty);

            var mb = ma.Sequence();

            Assert.True(mb == Empty);
        }

        [Fact]
        public void RightUnsafeSeqIsSeqRightUnsafe()
        {
            var ma = RightUnsafe<Error, Seq<int>>(Seq(1, 2, 3));

            var mb = ma.Sequence();

            Assert.True(mb == Seq(RightUnsafe<Error, int>(1), RightUnsafe<Error, int>(2), RightUnsafe<Error, int>(3)));
        }
    }
}