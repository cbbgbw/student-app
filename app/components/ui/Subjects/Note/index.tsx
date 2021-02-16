import { Button, Flex, Textarea } from '@chakra-ui/react'
import { Container } from '../Container'
import React from 'react'

export const SubjectNote = () => {
  return (
    <Container name="Notatki">
      <Flex alignItems="center" flexDir="column" paddingX="20px" width="100%">
        <Textarea
          backgroundColor="white"
          placeholder="Wpisz tutaj notatkę"
          resize="none"
          value={''}
          border="transparent"
        />
        <Button marginY="10px">WIĘCEJ NOTATEK</Button>
      </Flex>
    </Container>
  )
}
