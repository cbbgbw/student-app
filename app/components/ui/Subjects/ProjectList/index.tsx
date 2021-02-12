import { List, ListItem, Box, Flex, Text } from '@chakra-ui/react'
import { ProjectListItem } from './ProjectListItem'
import { useProjects } from '../../../../api/hooks/project'
import { Container } from '../Container'
import { useRouter } from 'next/router'
import { Head } from 'next/document'

export const ProjectList = () => {
  const { projects } = useProjects()
  const { push } = useRouter()

  return (
    <Container maxHeight="300px" name="PROJEKTY">
      <List px="20px" w="100%" display="flex" flexDir="column">
        {projects?.map((project) => {
          const date = new Date(project.deadlineTime)
          const onProjectLinkClick = () =>
            push(
              `/subjects/${project.subjectKey}/projects/${project.projectKey}`,
            )

          return (
            <ProjectListItem
              statusName={project.projectStatusName}
              onProjectNameClick={onProjectLinkClick}
              key={project.projectKey}
              name={project.name}
              deadlineFormatted={date.toDateString()}
              category={project.categoryName}
              isRequired={project.necessaryToPass}
              state={project.projectStatusName}
            />
          )
        })}
      </List>
    </Container>
  )
}
