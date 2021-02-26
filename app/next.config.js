// next.config.js
const withSourceMaps = require('@zeit/next-source-maps')
module.exports = withSourceMaps({
  webpack(config, options) {
    config.module.rules.push({
      test: /\.svg$/,
      use: ['@svgr/webpack'],
    })
    config.module.rules.push({
      test: /\.(png|jpe?g|gif)$/i,
      use: ['file-loader'],
    })
    return config
  },
})
