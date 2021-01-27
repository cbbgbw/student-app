import { Flex, Stack } from '@chakra-ui/react'
import { Button, ButtonGroup } from '@chakra-ui/react'

import React from 'react'
import { useRouter } from 'next/router'

const LoginPage = () => {
  const { push } = useRouter()

  return (
    <Flex
      align="center"
      justify={{
        base: 'center',
        md: 'space-around',
        xl: 'space-between',
      }}
      h="100vh"
      w="100vw"
    >
      <Stack direction="row" align="center">
        <Button colorScheme="purple">Zaloguj</Button>
        <Button
          onClick={() => push('/register')}
          colorScheme="purple"
        >
          Zarejestruj
        </Button>
      </Stack>
    </Flex>
  )
}

export default LoginPage
