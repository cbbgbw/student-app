import '../style.css'
import type { AppProps } from 'next/app'
import React from 'react'
import { ChakraProvider, extendTheme, GlobalStyle } from '@chakra-ui/react'
import { AuthProvider } from '../components/Auth/Provider'
import { ButtonStylesOverride } from '../consts/styles'

const colors = {}
const theme = extendTheme({
  fonts: {
    heading: 'Source Sans Pro',
    body: 'Source Sans Pro',
  },
  colors,
  components: {
    Button: ButtonStylesOverride,
  },
})

const global = {}

export const MyApp = ({ Component, pageProps }: AppProps) => {
  return (
    <ChakraProvider theme={theme}>
      <AuthProvider>
        <Component {...pageProps} />
      </AuthProvider>
    </ChakraProvider>
  )
}
export default MyApp
