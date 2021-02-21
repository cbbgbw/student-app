import useSWR from 'swr'
import { fetcher } from '../axios'

export interface Project {
  categoryKey: string
  categoryName: string
  mark: number
  name: string
  description: string
  deadlineTime: string
  necessaryToPass: boolean
  projectKey: string
  projectStatusKey: string
  projectStatusName: string
  subjectKey: string
  subjectTitle: string
  typeDefinitionKey: string
  typeDefinitionName: string
  workingAreaKey: string
  isArchive: boolean
}

export const useProjects = () => {
  const { data, error } = useSWR<Project[] | undefined>(
    'project/semester',
    fetcher,
  )

  const getAsKeyValue: Record<string, string> | unknown = () =>
    data?.reduce((prev, project) => {
      const { projectKey, name } = project
      return { ...prev, [projectKey]: name }
    }, {})

  return {
    projects: data,
    getAsKeyValue: getAsKeyValue,
  }
}

interface ProjectCount {
  countValue: number
  typeDefinitionKey: string
  typeName: string
}

export const useProjectCount = () => {
  const { data, error } = useSWR<ProjectCount[] | undefined>(
    'project/count',
    fetcher,
  )

  return {
    projectsCount: data,
  }
}

export const useProject = (projectKey: string) => {
  const { data, error } = useSWR<Project | undefined>(
    `project/${projectKey}`,
    fetcher,
  )

  return {
    project: data,
  }
}

export const useProjectForSubject = (subjectKey: string | undefined) => {
  const { data, error } = useSWR<Project[] | undefined>(
    subjectKey ? `project/subject/${subjectKey}` : null,
    fetcher,
  )

  return {
    projects: data,
  }
}
