import {
  Box,
  Button,
  Flex,
  FormControl,
  FormErrorMessage,
  Text,
} from '@chakra-ui/react'
import React from 'react'
import { useForm } from 'react-hook-form'
import { CInput } from '../../components/Forms/Input/CInput'
import { useRouter } from 'next/router'
import { postRegisterUser, RegisterUserFormData } from '../../api/actions/user'

const RegisterPage = () => {
  const { push } = useRouter()
  const { handleSubmit, errors, register, formState } = useForm()

  const onSubmit = async (data: RegisterUserFormData) => {
    const signInResult = await postRegisterUser(data)
    localStorage.setItem('token', JSON.stringify(signInResult.data.token))
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
        Rejestracja
      </Text>
      <Box my={4} w={300}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <FormControl isInvalid={errors.name}>
            <CInput
              labelText="Twoje imie"
              name="firstName"
              placeholder="Wpisz imię"
              ref={register()}
            />
            <FormErrorMessage>{errors.name?.message}</FormErrorMessage>
          </FormControl>
          <FormControl isInvalid={errors.name}>
            <CInput
              labelText="Twoje nazwisko "
              name="lastName"
              ref={register()}
            />
            <FormErrorMessage>{errors.name?.message}</FormErrorMessage>
          </FormControl>
          <FormControl isInvalid={errors.name}>
            <CInput labelText="Twój login" name="loginName" ref={register()} />
            <FormErrorMessage>{errors.name?.message}</FormErrorMessage>
          </FormControl>
          <FormControl isInvalid={errors.name}>
            <CInput
              labelText="Twój email"
              name="emailAddress"
              ref={register()}
            />
            <FormErrorMessage>{errors.name?.message}</FormErrorMessage>
          </FormControl>
          <FormControl isInvalid={errors.name}>
            <CInput
              labelText="Twoje hasło"
              type="password"
              name="password"
              ref={register()}
            />
            <FormErrorMessage>{errors.name?.message}</FormErrorMessage>
          </FormControl>
          <FormControl isInvalid={errors.name}>
            <CInput
              labelText="Twój semestr"
              name="semesterValue"
              ref={register()}
            />
            <FormErrorMessage>{errors.name?.message}</FormErrorMessage>
          </FormControl>
          <Button mt={3} type="submit" w="100%" colorScheme="purple">
            Utwórz konto
          </Button>
        </form>
      </Box>
    </Flex>
  )
}

export default RegisterPage
