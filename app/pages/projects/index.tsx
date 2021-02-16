import { Flex, Heading, List, ListItem } from '@chakra-ui/react'
import React from 'react'
import Zakladka from '../../public/icons/zakladka.svg'
import { Linker, LinkType } from '../../components/Linker'
import { useProjects } from '../../api/hooks/project'

export const ProjectPage = () => {
  const { projects } = useProjects()

  const renderItems = () =>
    projects?.map((project) => (
      <ListItem
        marginRight="20px"
        marginBottom="20px"
        key={project.name}
        width="300px"
        height="300px"
        border="1px solid #271257"
        borderRadius="15px"
      >
        <Flex flexDir="column" justifyContent="space-between">
          <Flex alignItems="center" justifyContent="flex-start">
            <Zakladka />
            <Flex flexDir="column">
              <Heading color="#271257" fontSize="3xl" marginRight="20px">
                <Linker type={LinkType.Subjects} typeKey={project.subjectKey}>
                  {project.subjectTitle}
                </Linker>
              </Heading>
            </Flex>
          </Flex>
          <Flex marginY="20px" paddingLeft="10px" flexDir="column">
            <Heading color="#271257" fontSize="2xl">
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
              5 DNI DO ZAKOŃCZENIA
            </Heading>
          </Flex>
        </Flex>
      </ListItem>
    )) // TODO Dodać odliczanie dni do konkretnego projektu

  return (
    <List
      as={Flex}
      padding="20px"
      backgroundColor="white"
      borderRadius="15px"
      width="100%"
      h="100%"
      overflow="auto"
    >
      {renderItems()}
    </List>
  )
}

export default ProjectPage
