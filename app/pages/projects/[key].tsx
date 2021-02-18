import {
  Flex,
  List,
  ListItem,
  Button,
  Heading,
  Box,
  Text,
} from '@chakra-ui/react'
import { useRouter } from 'next/router'
import React from 'react'
import { useProject } from '../../api/hooks/project'
import { FlexCentered } from '../../components/chakra/FlexCentered'
import { TinyEditor } from '../../components/page/Projects/Single/TinyEditor'

const ProjectPage = () => {
  const { query } = useRouter()
  const { project } = useProject(String(query.key))

  const events = [
    {
      date: '21 luty',
      name: 'Nauka fizyka',
    },
    {
      date: '23 luty',
      name: 'Spotkanie z Radkiem - nauka na skype',
    },
  ]

  const generateEvents = () => (
    <List px="20px" mt={'20px'}>
      {events.map(({ name, date }) => (
        <ListItem
          borderRadius={'15px'}
          padding={'20px'}
          mb="20px"
          backgroundColor="#ffffff"
        >
          <Heading>{date}</Heading>
          <Text fontSize={'2xl'}>{name}</Text>
        </ListItem>
      ))}
    </List>
  )

  return (
    <Flex flexDir="row" w="100%" h="100%">
      <Box>
        <Flex
          flexDir="row"
          padding="25px"
          background="white"
          borderRadius="15px"
        >
          <Flex alignItems="center" flexDir="column">
            <Heading>{project?.name}</Heading>
            <FlexCentered mt="36px" backgroundColor="#dcdaf2" h="60px" w="100%">
              <Heading color="#271257" fontSize="xl">
                {project?.subjectTitle}
              </Heading>
            </FlexCentered>
            <Flex flexDir="row">
              <FlexCentered
                mt="36px"
                mr="60px"
                backgroundColor="#271257"
                h="60px"
                w="300px"
              >
                <Heading color="white" fontSize="xl">
                  {project?.typeDefinitionName}
                </Heading>
              </FlexCentered>
              <FlexCentered
                mt="36px"
                backgroundColor="#271257"
                h="60px"
                w="300px"
              >
                <Heading color="white" fontSize="xl">
                  {project?.categoryName}
                </Heading>
              </FlexCentered>
            </Flex>
          </Flex>
          <Flex ml="75px" flexDir="column" justifyContent="space-between">
            <FlexCentered backgroundColor="#271257" h="60px" w="300px">
              <Heading color="white" fontSize="xl">
                {project?.deadlineTime}
              </Heading>
            </FlexCentered>
            <FlexCentered backgroundColor="#271257" h="60px" w="300px">
              <Heading color="white" fontSize="xl">
                {project?.projectStatusName}
              </Heading>
            </FlexCentered>
          </Flex>
        </Flex>
        <Flex flexDir="column" backgroundColor="white" mt="15px">
          <Heading h="80px" display="flex" alignItems="center" ml="25px">
            Notatki
          </Heading>
          <TinyEditor />
        </Flex>
      </Box>
      <Flex ml="30px" w="350px" flexDir="column">
        <Button borderRadius="15px" backgroundColor="#271257">
          EDYTUJ PROJEKT
        </Button>
        <Flex
          h="100%"
          borderRadius="15px"
          mt="40px"
          display="flex"
          alignItems="center"
          backgroundColor="#bba5e1"
          flexDir="column"
        >
          <Heading mt="36px" color="#ffffff">
            WYDARZENIA
          </Heading>
          {generateEvents()}
        </Flex>
      </Flex>
    </Flex>
  )
}

export default ProjectPage
