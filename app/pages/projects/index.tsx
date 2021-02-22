import { Flex, Heading, List, ListItem } from '@chakra-ui/react'
import React from 'react'
import Zakladka from '../../public/icons/zakladka.svg'
import { Linker, LinkType } from '../../components/Linker'
import { useProjects } from '../../api/hooks/project'
import moment from 'moment'

export const ProjectPage = () => {
  const { projects } = useProjects()

  const renderItems = () =>
    projects?.map((project) => (
      <ListItem
        marginRight="35px"
        marginBottom="35px"
        key={project.name}
        width="300px"
        minH="300px"
        maxH="400px"
        border="1px solid #271257"
        borderRadius="15px"
      >
        <Flex flexDir="column" justifyContent="space-between" h="100%">
          <Flex alignItems="center" justifyContent="flex-start">
            <Zakladka />
            <Flex flexDir="column">
              <Heading
                color="#271257"
                fontSize="3xl"
                marginRight="20px"
                wordBreak="break-word"
              >
                <Linker type={LinkType.Subjects} typeKey={project.subjectKey}>
                  {project.subjectTitle}
                </Linker>
              </Heading>
            </Flex>
          </Flex>
          <Flex marginY="20px" paddingLeft="10px" flexDir="column">
            <Heading color="#271257" fontSize="2xl" wordBreak="break-word">
              <Linker type={LinkType.Projects} typeKey={project.projectKey}>
                {project.name}
              </Linker>
            </Heading>
            <Heading color="#8896db" fontSize="2xl">
              {project.categoryName}
            </Heading>
          </Flex>
          <Flex
            borderRadius="15px"
            alignItems="center"
            justifyContent="center"
            backgroundColor="#271257"
            color="white"
            marginX="50px"
            marginY="10px"
          >
            <Heading paddingY="10px" paddingX="20px" fontSize="2xl">
              {project.projectStatusName}
            </Heading>
          </Flex>
          <Flex
            borderBottomRadius="15px"
            alignItems="center"
            justifyContent="center"
            borderTop="1px solid #271257"
          >
            <Heading paddingY="10px" fontSize="2xl">
              {moment(project.deadlineTime).locale('pl').format('LL')}
            </Heading>
          </Flex>
        </Flex>
      </ListItem>
    )) // TODO Dodać odliczanie dni do konkretnego projektu

  return (
    <Flex
      width="100%"
      h="100%"
      flexDir="column"
      borderRadius="15px"
      backgroundColor="#ffffff"
      padding="30px"
    >
      <List
        as={Flex}
        flexWrap="wrap"
        flexDir="row"
        paddingX="35px"
        backgroundColor="white"
        width="100%"
        h="100%"
        overflow="auto"
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
        {renderItems()}
      </List>
    </Flex>
  )
}

export default ProjectPage
