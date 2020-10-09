using Xunit;

public class testChallenge
{
    [Fact]
    public void PassingBalanceBrackets()
    {
        Assert.True(BracketsAndMultiples.Challenge.Balance("{}"));
        Assert.True(BracketsAndMultiples.Challenge.Balance(""));


        //checking for other situtations, like having other content in the string
        Assert.True(BracketsAndMultiples.Challenge.Balance("asdfsadf{asdfasdf}"));
        //Checking for ints
        Assert.True(BracketsAndMultiples.Challenge.Balance("{23534534}"));
        //Checking for muliple sets of brackets
        Assert.True(BracketsAndMultiples.Challenge.Balance("{{{23534534}}}"));
    }
    [Fact]
    public void FailingBalanceBrackets()
    {
        //Assert.Equal(true, JobNimbus.Challenge.Balance("{}"));
        Assert.False(BracketsAndMultiples.Challenge.Balance("}{"));
        Assert.False(BracketsAndMultiples.Challenge.Balance("{{}"));

        //Checking for other scenarios
        Assert.False(BracketsAndMultiples.Challenge.Balance("}"));
        Assert.False(BracketsAndMultiples.Challenge.Balance("{"));
        Assert.False(BracketsAndMultiples.Challenge.Balance("234234{"));
        Assert.False(BracketsAndMultiples.Challenge.Balance("{asdfasdf"));
    }
}