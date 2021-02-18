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
import { SubjectListItem } from '../../components/page/subjects/SubjectListItem'

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

  const renderItems = () => (
    <List
      flexWrap="wrap"
      as={Flex}
      flexDir="row"
      w="100%"
      //h="100%"
      overflow="auto"
      paddingX="30px"
      css={{
        '&::-webkit-scrollbar': {
          width: '10px',
        },
        '&::-webkit-scrollbar-track': {
          width: '6px',
          background: '#dadada',
          borderRadius: '24px',
        },
        '&::-webkit-scrollbar-thumb': {
          background: '#271257',
          borderRadius: '24px',
        },
      }}
    >
      {subjectArray?.map(
        ({ name, isPassed, typeDefinitionName, subjectKey }) => (
          <SubjectListItem
            name={name}
            subjectKey={subjectKey}
            isPassed={isPassed}
          />
        ),
      )}
    </List>
  )

  return (
    <Flex
      w="100%"
      h="100%"
      borderRadius="15px"
      padding="30px"
      backgroundColor="#ffffff"
      flexDirection="column"
    >
      <Flex paddingBottom="30px" justifyContent="flex-end">
        <Button
          backgroundColor="#271257"
          w="200px"
          h="55px"
          fontSize="20px"
          onClick={() => setModalType(ModalType.AddSubject)}
        >
          Dodaj przedmiot
        </Button>
      </Flex>
      {renderItems()}
    </Flex>
  )
}

export default SubjectListView
