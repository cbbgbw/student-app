import { ListSubject } from '../../components/page/Subject/ListSubject'
import React, { useContext } from 'react'
import { GlobalDataContext } from '../../components/Auth/Provider'
import { useSubjects, useSubjectTypes } from '../../api/hooks/subject'
import {
  Box,
  Button,
  Flex,
  Grid,
  GridItem,
  Heading,
  Link,
  List,
} from '@chakra-ui/react'
import { ModalType } from '../../types/types'
import { useRouter } from 'next/router'

export const SubjectListView = () => {
  const { setModalType } = useContext(GlobalDataContext)
  const { subjectArray, isLoading } = useSubjects()
  const subjectTypesRequest = useSubjectTypes()
  const { push } = useRouter()

  const renderSubjects = () =>
    !subjectTypesRequest.isLoading &&
    !isLoading &&
    subjectArray?.map(({ name, subjectKey, typeDefinitionKey }) => (
      <ListSubject
        key={subjectKey}
        type={
          subjectTypesRequest?.subjectTypes &&
          subjectTypesRequest?.subjectTypes[typeDefinitionKey]
        }
        name={name}
        subjectKey={subjectKey}
      />
    ))

  const renderItems = () =>
    subjectArray?.map(({ name, isPassed, typeDefinitionName, subjectKey }) => (
      <Flex
        borderRadius="15px"
        w="300px"
        flexDirection="column"
        alignItems="center"
        justifyContent="center"
        backgroundColor="#271257"
        key="name"
        marginRight="80px"
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
    ))

  return (
    <Box
      w="100%"
      borderRadius="15px"
      margin="50px"
      padding="40px"
      backgroundColor="#ffffff"
    >
      <Flex paddingBottom="20px" justifyContent="flex-end">
        <Button
          backgroundColor="#271257"
          onClick={() => setModalType(ModalType.AddSubject)}
        >
          Dodaj przedmiot
        </Button>
      </Flex>
      <List flexWrap="wrap" as={Flex} flexDir="row">
        {renderItems()}
      </List>
    </Box>
  )
}

export default SubjectListView
