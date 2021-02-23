import { Path, postByScheme, putByScheme } from '../axios'
import { v4 as uuidv4 } from 'uuid'
import { Project } from '../hooks/project'

interface ProjectProps {
  projectKey: string
}

export interface ProjectFormData {
  name: string
  typeDefinitionKey: string
  subjectKey: string
  categoryKey: string
  description: string
  deadlineTime: string
  necessaryToPass: boolean
}

type ProjectPost = ProjectFormData & ProjectProps

export const postProject = async (data: ProjectFormData) =>
  await postByScheme<ProjectPost>(Path.Project, {
    ...data,
    projectKey: uuidv4(),
  }).then((response) => response.status === 200)

export const projectPut = async (projectModified: Project) =>
  putByScheme<Project>(Path.Project, projectModified)
