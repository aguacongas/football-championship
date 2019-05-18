const webpack = require('webpack');
const path = require('path');

module.exports = {
    mode: 'development',
    entry: './js/amplify.js',
    output: {
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, 'content')
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/
            }
        ]
    },
    plugins: [
        new webpack.HotModuleReplacementPlugin()
    ]
};
