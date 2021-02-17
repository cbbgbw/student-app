import { Box, Flex, Heading, Link } from '@chakra-ui/react'
import { useRouter } from 'next/router'
import React, { FC } from 'react'

interface Props {
  name: string
  isPassed: boolean
  subjectKey: string
}

export const SubjectListItem: FC<Props> = ({ name, isPassed, subjectKey }) => {
  const { push } = useRouter()
  return (
    <Flex
      borderRadius="15px"
      w="300px"
      flexDirection="column"
      alignItems="center"
      justifyContent="space-between"
      backgroundColor="#271257"
      key="name"
      marginRight="35px"
      marginBottom="35px"
      textAlign="center"
      wordBreak="break-word"
    >
      <Heading mt="65px" color="white">
        <Link
          onClick={() =>
            push({
              pathname: '/subjects/[key]',
              query: {
                key: subjectKey,
              },
            })
          }
        >
          {name}
        </Link>
      </Heading>
      <Box
        display="flex"
        alignItems="center"
        justifyContent="center"
        height="46px"
        borderRadius="15px"
        w="260px"
        mb="15px"
        color="white"
        mt="130px"
        backgroundColor={isPassed ? '#4cd964' : '#fa0000'}
      >
        <Heading fontSize="2xl" display="flex" justifyContent="center">
          {isPassed ? 'zaliczony' : 'niezaliczony'}
        </Heading>
      </Box>
    </Flex>
  )
}
