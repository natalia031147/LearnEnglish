select * from Videos a 
left join UserProgresses b on a.Id = b.Video_id
where Level >= 2 and (ListeningModulePassed <> 1 or ListeningModulePassed is null)
order by Level, WritingModulePassed desc, a.id

select * from Videos a 
left join UserProgresses b on a.Id = b.Video_id
where Level >= 2 and (WritingModulePassed <> 1 or WritingModulePassed is null)
order by Level, ListeningModulePassed desc, a.id