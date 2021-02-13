import useSWR from 'swr'
import { fetcher } from '../axios'

export interface Project {
  projectKey: string
  name: string
  typeDefinitionName: string
  typeDefinitionKey: string
  description: string
  deadlineTime: string
  necessaryToPass: boolean
  projectStatusKey: string
  categoryKey: string
  subjectKey: string
  subjectTitle: string
  mark: number
  workingAreaKey: string
  isArchive: boolean
}

export const useProjects = () => {
  const { data, error } = useSWR<Project[] | undefined>(
    'project/semester',
    fetcher,
  )

  const getAsKeyValue = () =>
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
  count: number
  key: string
  name: string
}

export const useProjectCount = () => {
  const { data, error } = useSWR<Record<string, ProjectCount> | undefined>(
    'project/count',
    fetcher,
  )

  return {
    projectsCount: data,
  }
}
