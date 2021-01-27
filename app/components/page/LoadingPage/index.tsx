import { Flex } from '@chakra-ui/react'
import React from 'react'
import { CircleLoader } from 'react-spinners'

export const LoadingPage = () => (
  <Flex
    align="center"
    justify="center"
    height="100vh"
    width="100vw"
    position="absolute"
    top="0"
  >
    <CircleLoader color="purple" size={100} />
  </Flex>
)

export default LoadingPage
