import { List } from '@chakra-ui/react'
import { ProjectListItem } from './ProjectListItem'
import { useProjectForSubject } from '../../../../api/hooks/project'
import { Container } from '../Container'
import { FC } from 'react'

interface Props {
  subjectKey: string | undefined
}

export const ProjectList: FC<Props> = ({ subjectKey }) => {
  const { projects } = useProjectForSubject(subjectKey)

  return (
    <Container name="PROJEKTY">
      <List px="20px" w="100%" display="flex" flexDir="column">
        {projects?.map((project) => (
          <ProjectListItem key={project.projectKey} project={project} />
        ))}
      </List>
    </Container>
  )
}
