using Microsoft.JSInterop;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Aguacongas.AwsServices.Test
{
    public class AwsJsInteropTest
    {
        [Fact]
        public async Task ListenAsync_shoud_not_listen_twice()
        {
            var jsRuntimeMock = new Mock<IJSRuntime>();
            var awsHelperMock = new Mock<IAwsHelper>();

            jsRuntimeMock.Setup(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.hub.listen"),
                It.Is<IAwsHelper>(r => r == awsHelperMock.Object)))
                .ReturnsAsync(new object())
                .Verifiable();

            var sut = new AwsJsInterop(jsRuntimeMock.Object, awsHelperMock.Object);

            await sut.ListenAsync();
            await sut.ListenAsync();

            jsRuntimeMock.Verify(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.hub.listen"),
                It.Is<IAwsHelper>(r => r == awsHelperMock.Object)), Times.Exactly(1));
        }

        [Fact]
        public async Task ConfigureAsync_shoud_not_listen_twice()
        {
            var jsRuntimeMock = new Mock<IJSRuntime>();
            var awsHelperMock = new Mock<IAwsHelper>();
            var config = new AwsConfig();

            jsRuntimeMock.Setup(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.configure"),
                It.Is<AwsConfig>(c => c == config)))
                .ReturnsAsync(new object())
                .Verifiable();

            var sut = new AwsJsInterop(jsRuntimeMock.Object, awsHelperMock.Object);

            await sut.ConfigureAsync(config);
            await sut.ConfigureAsync(config);

            jsRuntimeMock.Verify(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.configure"),
                It.Is<AwsConfig>(c => c == config)), Times.Exactly(1));
        }

        [Fact]
        public async Task SignInAsync_should_call_corresponding_js()
        {
            var jsRuntimeMock = new Mock<IJSRuntime>();
            var awsHelperMock = new Mock<IAwsHelper>();
            var provider = "test";

            jsRuntimeMock.Setup(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.auth.federatedSignIn"),
                It.IsAny<string>()))
                .ReturnsAsync(new object())
                .Verifiable();

            var sut = new AwsJsInterop(jsRuntimeMock.Object, awsHelperMock.Object);

            await sut.SignInAsync(provider);
            await sut.SignInAsync(null);

            jsRuntimeMock.Verify(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.auth.federatedSignIn"),
                It.Is<string>(c => c == provider)), Times.Exactly(1));
            jsRuntimeMock.Verify(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.auth.federatedSignIn"),
                It.Is<string>(c => c == null)), Times.Exactly(1));
        }

        [Fact]
        public async Task SignOutAsync_should_call_corresponding_js()
        {
            var jsRuntimeMock = new Mock<IJSRuntime>();
            var awsHelperMock = new Mock<IAwsHelper>();

            jsRuntimeMock.Setup(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.auth.signout"),
                It.Is<IAwsHelper>(r => r == awsHelperMock.Object)))
                .ReturnsAsync(new object())
                .Verifiable();

            var sut = new AwsJsInterop(jsRuntimeMock.Object, awsHelperMock.Object);

            await sut.SignOutAsync();

            jsRuntimeMock.Verify(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.auth.federatedSignIn"),
                It.Is<IAwsHelper>(r => r == awsHelperMock.Object)), Times.Exactly(1));
        }

        [Fact]
        public async Task GraphQlAsync_should_call_corresponding_js()
        {
            var jsRuntimeMock = new Mock<IJSRuntime>();
            var awsHelperMock = new Mock<IAwsHelper>();

            jsRuntimeMock.Setup(m => m.InvokeAsync<GraphQlData<string>>(It.Is<string>(s => s == "amplifyWrapper.graphql.operation"),
                It.IsAny<string>(),
                It.IsAny<string>()))
                .ReturnsAsync(new GraphQlData<string>
                {
                    Data = "test"
                })
                .Verifiable();

            var sut = new AwsJsInterop(jsRuntimeMock.Object, awsHelperMock.Object);

            var response = await sut.GraphQlAsync<string>("test", "test");

            jsRuntimeMock.Verify(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.graphql.operation"),
                It.IsAny<string>(),
                It.IsAny<string>()), Times.Exactly(1));

            Assert.Equal("test", response);
        }

        [Fact]
        public async Task GraphSubscribeAsync_should_call_corresponding_js()
        {
            var jsRuntimeMock = new Mock<IJSRuntime>();
            var awsHelperMock = new Mock<IAwsHelper>();

            jsRuntimeMock.Setup(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.graphql.subsription"),
                It.Is<IAwsHelper>(r => r == awsHelperMock.Object),
                It.IsAny<string>()))
                .ReturnsAsync(new object())
                .Verifiable();

            var sut = new AwsJsInterop(jsRuntimeMock.Object, awsHelperMock.Object);

            await sut.GraphSubscribeAsync("test", awsHelperMock.Object, "test");

            jsRuntimeMock.Verify(m => m.InvokeAsync<object>(It.Is<string>(s => s == "amplifyWrapper.graphql.subsription"),
                It.Is<IAwsHelper>(r => r == awsHelperMock.Object),
                It.IsAny<string>()), Times.Exactly(1));
        }
    }
}
