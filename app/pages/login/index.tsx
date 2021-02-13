import {
  Flex,
  Stack,
  Button,
  Text,
  FormControl,
  Box,
  Link,
  FormErrorMessage,
} from '@chakra-ui/react'

import React from 'react'
import { useRouter } from 'next/router'
import { CInput } from '../../components/Forms/Input/CInput'
import { useForm } from 'react-hook-form'
import { authorizeUser, UserAuthorizeData } from '../../api/actions/user'

const LoginPage = () => {
  const { handleSubmit, errors, register, formState } = useForm()

  const { push } = useRouter()

  const validateLogin = () => {
    return true
  }

  const onSubmit = async (data: UserAuthorizeData) => {
    const loginResult = await authorizeUser(data)
    localStorage.setItem('token', JSON.stringify(loginResult.data.token))
    await push('/app')
  }

  return (
    <Flex
      align="center"
      direction="column"
      justify={{
        base: 'center',
      }}
      h="100vh"
      w="100vw"
    >
      <Text fontSize="5xl" mb={30}>
        Student App | αlfa
      </Text>
      <Box my={4} w={300}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <FormControl isInvalid={errors.name}>
            <CInput
              labelText="Twój login"
              name="loginName"
              placeholder="Wpisz login"
              ref={register({ validate: validateLogin })}
            />
            <FormErrorMessage>{errors.name?.message}</FormErrorMessage>
          </FormControl>

          <FormControl isInvalid={errors.name}>
            <CInput
              labelText="Hasło"
              name="password"
              type="password"
              placeholder="Wpisz hasło"
              ref={register({ validate: validateLogin })}
            />
            <FormErrorMessage>{errors.name?.message}</FormErrorMessage>
          </FormControl>
          <Button mt={3} type="submit" w="100%" colorScheme="purple">
            Zaloguj
          </Button>
          <Text mt={3}>
            Nie masz jeszcze konta?
            <Link color="purple.300" onClick={() => push('/register')}>
              {' '}
              Dołącz teraz!
            </Link>
          </Text>
        </form>
      </Box>
    </Flex>
  )
}

export default LoginPage
