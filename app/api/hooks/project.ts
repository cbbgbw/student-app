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

  const getAsKeyValue: () => Record<string, string> = () =>
    data?.reduce((prev, project) => {
      const { projectKey, name } = project
      return { ...prev, [projectKey]: name }
    }, {}) as Record<string, string>

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
  const { data, mutate, error } = useSWR<Project | undefined>(
    `project/${projectKey}`,
    fetcher,
  )

  return {
    project: data,
    mutate,
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
export const useProjectTypes = () => {
  const { data, error } = useSWR<Record<string, string> | undefined>(
    'project/types',
    fetcher,
  )

  return { projectTypes: data, isLoading: !error && !data, isError: error }
}
export const useProjectStatuses = () => {
  const { data, error } = useSWR<Record<string, string> | undefined>(
    `project/statuses`,
    fetcher,
  )

  return { projectStatuses: data, isLoading: !error && !data, isError: error }
}

interface ProjectCategory {
  categoryKey: string
  categoryName: string
  projectTypeKey: string
}

export const useProjectCategory = (projectTypeKey: string | undefined) => {
  const { data, error } = useSWR<ProjectCategory[] | undefined>(
    projectTypeKey ? `project/categories/${projectTypeKey}` : null,
    fetcher,
  )

  return {
    projectCategories: data?.reduce((prev, newVal) => {
      const { categoryKey, categoryName } = newVal
      return { ...prev, [categoryKey]: categoryName }
    }, {}),
    isLoading: !error && !data,
    isError: error,
  }
}
