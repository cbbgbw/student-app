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
import { EventList } from '../../components/ui/common/EventList'
import { useEvents } from '../../api/hooks/event'
import { Linker, LinkType } from '../../components/Linker'

const ProjectPage = () => {
  const { query } = useRouter()
  const { project } = useProject(String(query.key))
  const { events } = useEvents()

  return (
    <Flex flexDir="row" w="100%" h="100%" justifyContent="space-between">
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
                <Linker type={LinkType.Subjects} typeKey={project?.subjectKey}>
                  <Text>{project?.subjectTitle}</Text>
                </Linker>
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
        <Flex
          flexDir="column"
          backgroundColor="white"
          mt="15px"
          borderRadius="15px"
        >
          <Heading h="80px" display="flex" alignItems="center" ml="25px">
            Notatki
          </Heading>
          <TinyEditor />
        </Flex>
      </Box>
      <Flex ml="30px" w="350px" flexDir="column">
        <Button
          borderRadius="15px"
          backgroundColor="#271257"
          marginBottom="20px"
          h="7%"
        >
          EDYTUJ PROJEKT
        </Button>
        <EventList
          events={events?.filter((ev) => ev.projectKey === project?.projectKey)}
        />
      </Flex>
    </Flex>
  )
}

export default ProjectPage
