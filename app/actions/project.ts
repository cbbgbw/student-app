import useSWR from 'swr'
import { fetcher } from '../api/axios'

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
