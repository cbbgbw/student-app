import '../style.css'
import type { AppProps } from 'next/app'
import React from 'react'
import { useHydrate } from '../utils/storeUtils'
import { StoreProvider } from '../utils/storeProvider'
import { Navigation, navWidth } from '../components/Navigation/Navigation'
import { ModalWrapper } from '../forms/ModalWrapper'
import { AppBackgroundColor } from '../types/color'
import { ChakraProvider, extendTheme } from '@chakra-ui/react'
import { AuthProvider } from '../components/Auth/Provider'
import { ButtonStylesOverride } from '../consts/styles'

const colors = {}
const theme = extendTheme({
  colors,
  components: {
    Button: ButtonStylesOverride,
  },
})

export const MyApp = ({ Component, pageProps }: AppProps) => {
  return (
    <ChakraProvider theme={theme}>
      <StoreProvider store={useHydrate(pageProps.initialZustandState)}>
        <AuthProvider>
          <Component {...pageProps} />
        </AuthProvider>
      </StoreProvider>
      <style jsx global>
        {`
          body {
            background-color: ${AppBackgroundColor};
            //padding-left: ${navWidth}px;
            box-sizing: border-box;
          }

          h1,
          p,
          ul {
            margin: 0;
            padding: 0;
          }
        `}
      </style>
    </ChakraProvider>
  )
}
// Only uncomment this method if you have blocking data requirements for
// every single page in your application. This disables the ability to
// perform automatic static optimization, causing every page in your app to
// be server-side rendered.
//
// MyApp.getInitialProps = async (appContext : AppContext) => {
//   // calls page's `getInitialProps` and fills `appProps.pageProps`
//   const appProps = await App.getInitialProps(appContext);

//   return { ...appProps }
// }

export default MyApp
