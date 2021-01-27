import {
  Box,
  Button,
  Flex,
  NumberDecrementStepper,
  NumberIncrementStepper,
  NumberInput,
  NumberInputField,
  NumberInputStepper,
  Text,
} from '@chakra-ui/react'
import React, { useState } from 'react'
import { useRouter } from 'next/router'
import { useAuth } from '../../hooks/useAuth'
import { Path, request } from '../../actions/common/common'
import { SemesterNumberInput } from '../../components/SemesterSelect'

const RegisterPage = () => {
  const [semester, setSemester] = useState(1)
  const { mutateSemester } = useAuth()

  const { push } = useRouter()

  const onSemesterSubmit = async () => {
    const path = Path.Semester
    const response = await request.bodyLessPost(`${path}/${semester}`)
    mutateSemester({ [response]: String(semester) })
  }

  return (
    <Flex h="100vh" w="full" align="center" justifyContent="center">
      <Box
        p={8}
        bg="purple.400"
        maxWidth="500px"
        borderWidth={1}
        borderRadius={8}
        boxShadow="lg"
        align="center"
      >
        <Text color="purple.50" align="left" mb={1} fontSize="xl">
          Wybierz semestr
        </Text>
        <SemesterNumberInput
          semester={semester}
          onChange={(n) => setSemester(n)}
        />
        <Button onClick={() => onSemesterSubmit()} colorScheme="purple">
          Przejdź dalej
        </Button>
      </Box>
    </Flex>
  )
}

export default RegisterPage
